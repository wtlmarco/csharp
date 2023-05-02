namespace App.Settings;

//Para usar esse serviço é necessário gerar uma chave no site da empresa
//que será utlizada no campo Senha

public class SendingBlueSettings
{
    public string NomeRemetente { get; set; }

    public string EmailRemetente { get; set; }

    public string Senha { get; set; }

    public string EnderecoServidor { get; set; }

    public int PortaServidor { get; set; }

    public bool UsarSsl { get; set; }
}