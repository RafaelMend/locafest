class Cliente {
  String id;
  String nome;
  String cpf;
  String aniversario;
  String usuarioId;
  String enderecoId;

  Cliente(
      {this.id,
      this.nome,
      this.cpf,
      this.aniversario,
      this.usuarioId,
      this.enderecoId});

  Cliente.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    nome = json['nome'];
    cpf = json['cpf'];
    aniversario = json['aniversario'];
    usuarioId = json['usuarioId'];
    enderecoId = json['enderecoId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['nome'] = this.nome;
    data['cpf'] = this.cpf;
    data['aniversario'] = this.aniversario;
    data['usuarioId'] = this.usuarioId;
    data['enderecoId'] = this.enderecoId;
    return data;
  }
}