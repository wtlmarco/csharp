namespace CadastroDePacientes.API.Models.Validators.Helpers;

public static class ValidatorsHelpers
{
    public static bool IsValidCpf(string data, bool validateNull = false, bool validateEmpty = false)
    {
        if (!validateNull && data == null)
            return true;

        if (!validateEmpty && data.Trim() == "")
            return true;

        string value = data.Replace(".", "");
        value = value.Replace("-", "");

        if (value.Length != 11)
        {
            return false;
        }

        bool same = true;

        for (int i = 1; i < 11 && same; i++)
        {
            if (value[i] != value[0])
            {
                same = false;
            }
        }

        if (same || value == "12345678909")
        {
            return false;
        }

        int[] numbers = new int[11];

        for (int i = 0; i < 11; i++)
        {
            numbers[i] = int.Parse(value[i].ToString());
        }

        int sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += (10 - i) * numbers[i];
        }

        int result = sum % 11;

        if (result == 1 || result == 0)
        {
            if (numbers[9] != 0)
            {
                return false;
            }
        }
        else if (numbers[9] != 11 - result)
        {
            return false;
        }

        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += (11 - i) * numbers[i];
        }

        result = sum % 11;

        if (result == 1 || result == 0)
        {
            if (numbers[10] != 0)
            {
                return false;
            }
        }
        else
        {
            if (numbers[10] != 11 - result)
            {
                return false;
            }
        }

        return true;
    }

}
