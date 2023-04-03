namespace Aula09;

static class Extensions{
    public static bool HasOnlyDigits(this string valor){
        const string digitos = "0123456789";

        foreach(char c in valor){
            if(!digitos.Contains(c)){
                return false;
            }
        }

        return true;
    }  
}