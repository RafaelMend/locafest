import 'cliente.dart';
import 'operador.dart';

class Usuario {
  String id;
  String senha;
  Cliente cliente;
  Operador operador;

  Usuario({this.id, this.senha});

  Usuario.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    senha = json['senha'];
    cliente = Cliente.fromJson(json['cliente']);
    operador = Operador.fromJson(json['operador']);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['senha'] = this.senha;
    data["cliente"]  = this.cliente.toJson();
    data["operador"]  = this.operador.toJson();
    return data;
  }
}