class Endereco {
  String id;
  String cep;
  String logradouro;
  String numero;
  String complemento;
  String cidade;
  String estado;

  Endereco(
      {this.id,
      this.cep,
      this.logradouro,
      this.numero,
      this.complemento,
      this.cidade,
      this.estado});

  Endereco.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    cep = json['cep'];
    logradouro = json['logradouro'];
    numero = json['numero'];
    complemento = json['complemento'];
    cidade = json['cidade'];
    estado = json['estado'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['cep'] = this.cep;
    data['logradouro'] = this.logradouro;
    data['numero'] = this.numero;
    data['complemento'] = this.complemento;
    data['cidade'] = this.cidade;
    data['estado'] = this.estado;
    return data;
  }
}