using System.Text.RegularExpressions;
using Take.Blip.Utils.Models.Base;
using Take.Blip.Utils.Models.Dtos;
using Take.Blip.Utils.Models.Dtos.Input;

namespace Take.Blip.Utils.Models.Validators;

public sealed class CPFValidator : DataValidator
{  
  private const int CPF_LENGTH = 11;
  private const string CPF_FORMAT = "{0}.{1}.{2}-{3}";
  private const string MASKED_CPF_FORMAT = "***.***.{0}-{1}";

  public CPFValidator(string input) : base(input) 
  { 
  }

  protected override string Formatter(string cpf) => 
    string.Format(CPF_FORMAT, 
      cpf.Substring(0, 3), 
      cpf.Substring(3, 3), 
      cpf.Substring(6, 3), 
      cpf.Substring(9, 2));

  protected override bool Validator(string cpf)
  {
      if (!HasValidLength(cpf) || HasAllDigitsEqual(cpf))
        return false;

      return IsValidCpf(cpf);
  }

  protected override string Cleaner(string input) => 
    Regex.Replace(input.Trim(), @"\D+", "", RegexOptions.IgnoreCase);

  public override BaseValidationResponse ProcessValidation()
  {
    var validation = (ValidationResponse) base.ProcessValidation();

    var cpfResponse = new CPFValidationResponse(validation.Data)
    {
      Masked = validation.Data.IsValid ? 
        GetMaskedCpf(validation.Data.Value) : Constants.UNEXPECTED_INPUT
    };

    return new ValidationResponse<CPFValidationResponse>(cpfResponse);
  }
  
  #region CPF private methods
  private static bool HasValidLength(string cpf) => 
    !string.IsNullOrWhiteSpace(cpf) && cpf.Length == CPF_LENGTH;

  private static bool HasAllDigitsEqual(string cpf) => 
    cpf.Distinct().Count() == 1;
    
  private string GetMaskedCpf(string cpf) => 
    string.Format(MASKED_CPF_FORMAT, cpf.Substring(6, 3), cpf.Substring(9, 2));

  private static string GetDigit(int sum) 
  {
    var rest = sum % 11;

    var digit = rest >= 2 ? (11 - rest) : 0;

    return digit.ToString();
  }

  private static int MakeSum(string cpf, int[] weight) 
  {
    var sum = 0;

    for (int pos = 0; pos < weight.Count(); pos++)
    {
      sum += int.Parse(cpf[pos].ToString()) * weight[pos];
    }

    return sum;
  }

  private static bool IsValidCpf(string cpf)
  {
    var FIRST_WEIGHT = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    var SECOND_WEIGHT = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

		var tempCpf = cpf.Substring(0, 9);
		
    var firstDigitWeightSum = MakeSum(tempCpf, FIRST_WEIGHT);		
		var firstDigit = GetDigit(firstDigitWeightSum);

		tempCpf = tempCpf + firstDigit;

		var secondDigitWeightSum = MakeSum(tempCpf, SECOND_WEIGHT);		
		var secondDigit = GetDigit(secondDigitWeightSum);

		return cpf.EndsWith(firstDigit + secondDigit);
  }
  #endregion
}