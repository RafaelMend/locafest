import 'dart:io';
import 'package:dio/dio.dart';
import 'package:connectivity/connectivity.dart';
import 'package:locafest/app/shared/utils/configuracao.dart';
import 'package:http/http.dart' as http;

class Connection {
  var dio = Dio();
  final servidor = properties["UrlBaseTest"];

  Future<String> ServicoGet(String url) async{
    try {
      var connectivityResult = await (Connectivity().checkConnectivity());
      if (connectivityResult == ConnectivityResult.none) {
        throw SocketException("Internet indisponível.");
      }
      final response = await http.get(servidor + url);

      if (response.statusCode == 200) {
        return response.body;
      }
    } catch (error) {
      print(error);
    }
  }

  Future<String> criandoServicoPostComDio(String url, String body ) async{
    try {
      var connectivityResult = await (Connectivity().checkConnectivity());
      if (connectivityResult == ConnectivityResult.none) {
        throw SocketException("Internet indisponível.");
      }
      final response = await dio.post(url, data: body);

      if (response.statusCode == 200) {
        return response.data;
      }
    } catch (error) {
      print(error);
    }
  }
}