import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/shared/components/drawer_component.dart';
import 'package:locafest/app/shared/components/map_component.dart';
import 'package:locafest/app/utils/hex_color.dart';
import 'package:datetime_picker_formfield/datetime_picker_formfield.dart';
import 'package:intl/intl.dart';


class NovaReservaPage extends StatefulWidget {
  @override
  _NovaReservaPageState createState() => _NovaReservaPageState();
}

class _NovaReservaPageState extends State<NovaReservaPage> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  var exibirErros = false;
  final format = DateFormat("dd/MM/yyyy hh:MM:ss");

  void initState() {}

  final _tLocal = TextEditingController(text: "");
  final _tDataRetirada = TextEditingController(text: "");
  final _tDataDevolucao = TextEditingController(text: "");

  @override
  Widget build(BuildContext cntext) {
    return Scaffold(
      backgroundColor: HexColor("#6b4891"),
      appBar: AppBar(
        title: Text('Locafest'),
        backgroundColor: HexColor("#9C27B0"),
      ),
      body: _body(context),
      drawer: DrawerComponent(),

    );
  }

  _body(BuildContext context) {
    return new Form(
      key: _formKey,
      child: new ListView(
        children: <Widget>[
          Padding(
            padding: const EdgeInsets.all(16),
            child: Text(
              "Nova Reserva",
              textAlign: TextAlign.center,
              style: TextStyle(
                fontSize: 24,
                fontWeight: FontWeight.bold,
                color: Colors.white
              ),
            ),
          ),
          Container(
            width: 30,
            height: 300,
            child: MapComponent(),
          ),
          Padding(
            padding: const EdgeInsets.all(16),
            child: Column(
              children: <Widget>[
                TextFormField(
                  key: Key("local"),
                  controller: _tLocal,
                  validator: _validateLocal,
                  keyboardType: TextInputType.number,
                  style: TextStyle(color: Colors.yellow),
                  decoration: InputDecoration(
                    labelText: "Local",
                    labelStyle: TextStyle(color: Colors.white),
                    enabledBorder: UnderlineInputBorder(
                      borderSide: BorderSide(color: Colors.white),
                    ),
                  ),
                ),
                DateTimeField(
                  format: format,
                  validator: _validateDataRetirada,
                  controller: _tDataRetirada,
                  style: TextStyle(color: Colors.yellow),
                  decoration: InputDecoration(
                    labelText: "Data de Retirada",
                    labelStyle: TextStyle(color: Colors.white),
                    enabledBorder: UnderlineInputBorder(
                      borderSide: BorderSide(color: Colors.white),
                    ),
                  ),
                  onShowPicker: (context, currentValue) {
                    return showDatePicker(
                        context: context,
                        firstDate: DateTime(1900),
                        initialDate: DateTime(1980),
                        lastDate: DateTime(2100));
                  },
                ),
                DateTimeField(
                  format: format,
                  validator: _validateDataDevolucao,
                  style: TextStyle(color: Colors.yellow),
                  controller: _tDataDevolucao,
                  decoration: InputDecoration(
                    labelText: "Data de Devolução",
                    labelStyle: TextStyle(color: Colors.white),
                    enabledBorder: UnderlineInputBorder(
                      borderSide: BorderSide(color: Colors.white),
                    ),
                  ),
                  onShowPicker: (context, currentValue) {
                    return showDatePicker(
                        context: context,
                        firstDate: DateTime(1900),
                        initialDate: DateTime(1980),
                        lastDate: DateTime(2100));
                  },
                ),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(16),
            child: RaisedButton(
              color: Colors.purple,
              child: Text(
                "Solicitar Nova Reserva",
                style: TextStyle(
                  color: Colors.yellow,
                  fontSize: 18,
                ),
              ),
              onPressed: () => _onClickFinalizarCadastro(),
            ),
          ),
        ],
      ),
    );
  }

  String _validateDataRetirada(DateTime text) {
    if (text == null) {
      return "É necessário selecionar uma data de retirada.";
    }
    return null;
  }

  String _validateDataDevolucao(DateTime text) {
    if (text == null) {
      return "É necessário selecionar uma data de devolução.";
    }
    return null;
  }

  String _validateLocal(String text) {
    if (text.isEmpty) {
      return "É necessário selecionar um local.";
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

  _onClickFinalizarCadastro() {}
}
