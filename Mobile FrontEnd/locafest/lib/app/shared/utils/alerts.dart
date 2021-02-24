import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'hex_color.dart';
import 'nav.dart';

alert(BuildContext context, String title, String msg, {Function callback}) {
  showDialog(
    context: context,
    builder: (context) {
      return AlertDialog(
        title: Text(title),
        content: Text(msg),
        actions: <Widget>[
          FlatButton(
            child: Text("OK"),
            onPressed: () {
              Navigator.pop(context);
              if (callback != null) {
                callback();
              }
            },
          )
        ],
      );
    },
  );
}


alertToast(BuildContext context, String msg) {
  Fluttertoast.showToast(
      msg: msg,
      toastLength: Toast.LENGTH_LONG,
      gravity: ToastGravity.CENTER,
      timeInSecForIosWeb: 5,
      backgroundColor: Colors.white70,
      textColor: Colors.black87,
      fontSize: 16.0
  );
}

alertComOpcao(
    BuildContext context, String title, String msg, Function callbackOk,
    {Function callbackCancelar}) {
  showDialog(
    context: context,
    builder: (context) {
      return AlertDialog(
        title: Row(
          children: <Widget>[
            Container(
              height: 30,
              width: 30,
              child: Image(
                image: new AssetImage("assets/images/logotipo.png"),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                title,
                style: TextStyle(
                  fontSize: 16,
                ),
              ),
            ),
          ],
        ),
        content: Text(msg),
        actions: <Widget>[
          FlatButton(
            child: Text("Não"),
            onPressed: () {
              Navigator.pop(context);
              if (callbackCancelar != null) {
                callbackCancelar();
              }
            },
          ),
          FlatButton(
            child: Text("Sim"),
            onPressed: () {
              Navigator.pop(context);
              if (callbackOk != null) {
                callbackOk();
              }
            },
          ),
        ],
      );
    },
  );
}

alertComOpcao2(
    BuildContext context, String msg, Function callbackOk,
    {Function callbackCancelar}) {
  showDialog(
    context: context,
    builder: (context) {
      double c_width = MediaQuery.of(context).size.width * 0.8;

      return AlertDialog(
        title: Container(
          child: Row(
            children: <Widget>[
              Container(
                height: 50,
                width: 50,
                child: Image(
                  image: new AssetImage("assets/images/logotipo.png"),
                ),
              ),
              Card(
                elevation: 10,
                child: Container(
                  width: c_width - 123,
                  alignment: AlignmentDirectional(0,-1),
                  child: Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Text(
                      msg,
                      style: TextStyle(
                        fontSize: 14,
                      ),
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
        actions: <Widget>[
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              width: 105,
              height: 35,
              child: FlatButton(
                color: HexColor("#9C27B0"),
                textColor: Colors.white,
                padding: EdgeInsets.all(8.0),
                splashColor: Colors.blueAccent,
                onPressed: () {
                  Navigator.pop(context);
                  if (callbackCancelar != null) {
                    callbackCancelar();
                  }
                },
                child: Text(
                  "NÃO",
                  style: TextStyle(fontSize: 12),
                ),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              width: 105,
              height: 35,
              child: FlatButton(
                color: HexColor("#9C27B0"),
                textColor: Colors.white,
                padding: EdgeInsets.all(8.0),
                onPressed: () {
                  Navigator.pop(context);
                  if (callbackOk != null) {
                    callbackOk();
                  }
                },
                child: Text(
                  "SIM",
                  style: TextStyle(fontSize: 12),
                ),
              ),
            ),
          ),
        ],
      );
    },
  );
}

alertWithRedirect(
    BuildContext context, String title, String msg, StatefulWidget tela) {
  showDialog(
    context: context,
    builder: (context) {
      return AlertDialog(
        title: Row(
          children: <Widget>[
            Container(
              height: 30,
              width: 30,
              child: Image(
                image: new AssetImage("assets/images/logotipo.png"),
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Text(
                title,
                style: TextStyle(
                  fontSize: 16,
                ),
              ),
            ),
          ],
        ),
        content: Text(msg),
        actions: <Widget>[
          FlatButton(
            child: Text("OK"),
            onPressed: () {
              Navigator.pop(context);
              if (tela != null) {
                pushReplacement(context, tela);
              }
            },
          )
        ],
      );
    },
  );
}
