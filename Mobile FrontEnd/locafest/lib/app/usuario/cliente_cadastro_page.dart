import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/shared/utils/hex_color.dart';

class UsuarioCadastroPage extends StatefulWidget {
  @override
  _UsuarioCadastroPageState createState() => _UsuarioCadastroPageState();
}

class _UsuarioCadastroPageState extends State<UsuarioCadastroPage> {
  bool _passwordVisible = true;
  bool _passwordVisibleConfirmacao = true;
  final _tLogin = TextEditingController(text: "");
  final _tSenha = TextEditingController(text: "");
  final _tSenhaConfirmacao = TextEditingController(text: "");

  void initState() {
    super.initState();
  }

  Color gradientStart = HexColor("#6b4891");
  Color gradientCenter = HexColor("#6b4891");
  Color gradientEnd = HexColor("#e1bee7");

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Locafest"),
        backgroundColor: HexColor("#9C27B0"),
      ),
      backgroundColor: Colors.white,
      body: _body(),
    );
  }

  _body() {
    return new Form(
      child: Container(
        decoration: BoxDecoration(
          gradient: LinearGradient(
            colors: [gradientStart, gradientCenter, gradientEnd],
            begin: const FractionalOffset(0.0, 0.0),
            end: const FractionalOffset(0.0, 0.9),
          ),
        ),
        child: Padding(
          padding: const EdgeInsets.all(16),
          child: new ListView(
            children: <Widget>[
              Text(
                "Cadastro",
                textAlign: TextAlign.center,
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.bold,
                  color: Colors.white
                ),
              ),
              TextFormField(
                controller: _tLogin,
                validator: _validateLogin,
                keyboardType: TextInputType.text,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 18,
                ),
                decoration: InputDecoration(
                  labelText: "Login",
                  labelStyle: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                  ),
                  hintText: "CPF ou Matrícula",
                  hintStyle: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                  ),
                ),
              ),
              TextFormField(
                controller: _tSenha,
                validator: _validateSenha,
                obscureText: _passwordVisible,
                keyboardType: TextInputType.number,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 18,
                ),
                decoration: InputDecoration(
                  labelText: "Senha",
                  enabledBorder: UnderlineInputBorder(
                    borderSide: BorderSide(color: Colors.white),
                  ),
                  labelStyle: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                  ),
                  hintText: "Senha",
                  hintStyle: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                  ),
                  suffixIcon: IconButton(
                      icon: Icon(
                        _passwordVisible ? Icons.visibility_off : Icons.visibility,
                        semanticLabel: _passwordVisible
                            ? "Exibir"
                            : "Ocultar",
                        color: Colors.white,
                      ),
                      onPressed: () {
                        setState(() {
                          _passwordVisible = !_passwordVisible;
                        });
                      }),
                ),
              ),
              TextFormField(
                controller: _tSenhaConfirmacao,
                validator: _validateSenhaConfirmacao,
                obscureText: _passwordVisibleConfirmacao,
                keyboardType: TextInputType.number,
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 18,
                ),
                decoration: InputDecoration(
                  labelText: "Confirmação de senha",
                  enabledBorder: UnderlineInputBorder(
                    borderSide: BorderSide(color: Colors.white),
                  ),
                  labelStyle: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                  ),
                  hintText: "Confirmação de senha",
                  hintStyle: TextStyle(
                    color: Colors.white,
                    fontSize: 18,
                  ),
                  suffixIcon: IconButton(
                      icon: Icon(
                        _passwordVisibleConfirmacao
                            ? Icons.visibility_off
                            : Icons.visibility,
                        semanticLabel: _passwordVisibleConfirmacao
                            ? "Exibir"
                            : "Exibir",
                        color: Colors.white,
                      ),
                      onPressed: () {
                        setState(() {
                          _passwordVisibleConfirmacao =
                              !_passwordVisibleConfirmacao;
                        });
                      }),
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 16, 0, 0),
                child: RaisedButton(
                  color: Colors.purple,
                  child: Text(
                    "Finalizar",
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 18,
                    ),
                  ),
                  onPressed: () => _onClickFinalizarCadastro(),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  String _validateLogin(String text) {
    if (text.isEmpty) {
      return "Login inválido";
    }

    return null;
  }

  String _validateSenha(String text) {
    if (text.isEmpty) {
      return "A Senha é inválida";
    }
    if (text.length <= 2) {
      return "A Senha precisa ter mais de dois digitos.";
    }

    return null;
  }

  String _validateSenhaConfirmacao(String text) {
    if (text.isEmpty) {
      return "A Senha é inválida";
    }
    if (text.length <= 2) {
      return "A Senha precisa ter mais de dois digitos.";
    }
    final senha = _tSenha.text;
    if (text != senha) {
      return "As senhas devem ser iguais.";
    }
    return null;
  }

  _onClickFinalizarCadastro() {}
}
