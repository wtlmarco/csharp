export interface Paciente {
    id: string;
    nome: string;
    sobrenome: string;
    dataDeNascimento: Date;
    genero: string;
    cpf: string;
    rg: string;
    ufDoRG: string;
    email: string;
    celular: string;
    telefoneFixo: string;
    convenioID: string;
    convenio: {
        id: string;
        nome: string;
    };
    carteirinhaDoConvenio: string;
    validadeDaCarteirinha: Date;
}