class Usuario {
  String id;
  String senha;

  Usuario({this.id, this.senha});

  Usuario.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    senha = json['senha'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['senha'] = this.senha;
    return data;
  }
}