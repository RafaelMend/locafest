import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/home/home_page.dart';
import 'package:locafest/app/utils/hex_color.dart';
import 'package:locafest/app/utils/nav.dart';

class LoginPage extends StatefulWidget {
  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {

  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  bool _passwordVisible = true;
  final _tLogin = TextEditingController(text: "");
  final _tSenha = TextEditingController(text: "");

  Color gradientStart = HexColor("#6b4891");
  Color gradientCenter = HexColor("#6b4891");
  Color gradientEnd = HexColor("#e1bee7");

  void initState() {
  }

  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: HexColor("#6b4891"),
      body: _body(context),
    );
  }

  _body(BuildContext context) {
    return Form(
      key: _formKey,
        child: Container(
          decoration: BoxDecoration(
            gradient: LinearGradient(
              colors: [gradientStart, gradientCenter, gradientEnd],
              begin: const FractionalOffset(0.0, 0.0),
              end: const FractionalOffset(0.0, 0.9),
            ),
          ),
            child: Padding(
            padding: const EdgeInsets.all(24.0),
              child: ListView(
                children: <Widget>[
                  Row(mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                            Column(
                                children: <Widget>[
                                  _img(),
                                  Text(
                                    "LOCAFEST",
                                    style: TextStyle(
                                      fontSize: 21,
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold,
                                    ),
                                  ),
                                ],
                            )

                  ]),
                  TextFormField(
                    key: Key("matricula"),
                    controller: _tLogin,
                    validator: _validateLogin,
                    maxLength: 11,
                    keyboardType: TextInputType.number,
                    style: TextStyle(color: Colors.white),
                    decoration: InputDecoration(
                      labelText: "Matrícula",
                      labelStyle: TextStyle(color: Colors.white),
                      enabledBorder: UnderlineInputBorder(
                        borderSide: BorderSide(color: Colors.white),
                      ),
                    ),
                  ),
                  TextFormField(
                    controller: _tSenha,
                    validator: _validateSenha,
                    obscureText: _passwordVisible,
                    keyboardType: TextInputType.text,
                    style: TextStyle(color: Colors.white),
                    decoration: InputDecoration(
                      labelText: "Senha",
                      labelStyle: TextStyle(color: Colors.white),
                      enabledBorder: UnderlineInputBorder(
                        borderSide: BorderSide(color: Colors.white),
                      ),
                      suffixIcon: IconButton(
                          icon: Icon(
                            _passwordVisible ? Icons.visibility_off : Icons.visibility,
                            semanticLabel:
                            _passwordVisible ? 'hide password' : 'show password',
                            color: Colors.white,
                          ),
                          onPressed: () {
                            setState(() {
                              _passwordVisible = !_passwordVisible;
                            });
                          }),
                    ),
                  ),
                  Center(
                    child: Padding(
                      padding: const EdgeInsets.all(16.0),
                      child: GestureDetector(
                          child: Text("Esqueci minha senha",
                              style: TextStyle(color: Colors.white)),
                          onTap: () {
                            print("Entrou no botão Recuperar senha");
                          }),
                    ),
                  ),
                  RaisedButton(
                    color: Colors.teal,
                    child: Text(
                      "ENTRAR",
                      style: TextStyle(
                        color: Colors.white,
                        fontSize: 20,
                      ),
                    ),
                    onPressed: () => _onClickEntrar(),
                  ),
                  Center(
                    child: Padding(
                      padding: const EdgeInsets.all(16.0),
                      child: GestureDetector(
                          child: Text("Não tem conta? Registrar",
                              style: TextStyle(color: Colors.white)),
                          onTap: () {
                            _onClickCadastrar(context);
                          }),
                    ),
                  ),
                ],
              ),
            ),
        )
    );
  }

  String _validateLogin(String text) {
    if (text.isEmpty) {
      return "Informe o login";
    }

    return null;
  }

  String _validateSenha(String text) {
    if (text.isEmpty) {
      return "Informe a senha";
    }
    if (text.length <= 2) {
      return "Senha precisa ter mais de 2 números";
    }

    return null;
  }

  _img() {
    return Container(
      width: 150,
      height: 150,
      child: Image.asset("assets/images/ic_carro_inicial.png"),
    );
  }

  _onClickEntrar() {
    pushReplacement(context, HomePage());
  }

  _onClickCadastrar(BuildContext context) {}
}