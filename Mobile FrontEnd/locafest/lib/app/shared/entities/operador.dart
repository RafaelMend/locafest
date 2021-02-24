class Operador {
  String id;
  String matricula;
  String nome;
  String usuarioId;

  Operador({this.id, this.matricula, this.nome, this.usuarioId});

  Operador.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    matricula = json['matricula'];
    nome = json['nome'];
    usuarioId = json['usuarioId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['matricula'] = this.matricula;
    data['nome'] = this.nome;
    data['usuarioId'] = this.usuarioId;
    return data;
  }
}