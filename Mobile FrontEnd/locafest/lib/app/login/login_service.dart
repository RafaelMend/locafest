import 'package:locafest/app/shared/entities/cliente.dart';
import 'package:locafest/app/shared/entities/usuario.dart';
import 'package:locafest/app/shared/utils/connection.dart';
import 'package:locafest/app/shared/utils/resonse.dart';
import 'package:uuid/uuid.dart';
import 'dart:convert' as convert;

class LoginService {
  var uuid = Uuid();

  Connection conexao = Connection();
  final endpoint = "";

  Future<Response> loginMock(String login, String senha) async {
    final usuario = new Usuario();
    usuario.id = uuid.v1();
    usuario.senha = senha;
    usuario.cliente = new Cliente();
    usuario.cliente.cpf = login;
    usuario.cliente.nome = "Rafael Mendonça";

    final response = Response.FromObject(true, "Dado mockado", usuario);

    return response;
  }

  Future<Response> login(String login, String senha) async {
    var retorno = await conexao.ServicoGet(endpoint);
    Map<String, dynamic> parsedList = convert.jsonDecode(retorno);
    return Response.FromObject(true, "Dado mockado", Usuario.fromJson(parsedList));
  }
}