class Response {
  final bool _ok;
  final String msg;
  Object _objeto;
  bool _validacao;
  String _url;
  int _id;

  Response(this._ok, this.msg);

  Response.FromResponse(bool ok, String msg, bool validacao)
      : _ok = ok,
        msg = msg,
        _validacao = validacao;

  Response.FromObject(bool ok, String msg, Object objeto)
      : _ok = ok,
        msg = msg,
        _objeto = objeto;

  Response.fromJson(Map<String, dynamic> map)
      : _ok = map["status"] == "OK",
        msg = map["msg"],
        _id = map["id"] as int,
        _url = map["url"],
        _validacao = map["validacao"];

  bool isOk() {
    return _ok;
  }

  bool isValidate() {
    return _validacao;
  }

  Object getObjeto() {
    return _objeto;
  }
}
