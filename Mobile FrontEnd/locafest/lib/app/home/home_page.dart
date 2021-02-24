import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/reserva/minhas_reservas_page.dart';
import 'package:locafest/app/reserva/nova_reserva_page.dart';
import 'package:locafest/app/shared/entities/usuario.dart';
import 'package:locafest/app/shared/utils/hex_color.dart';
import 'package:locafest/app/shared/utils/nav.dart';
import '../shared/components/drawer_component.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();

  final Usuario usuario;
  HomePage(this.usuario);
}

class _HomePageState extends State<HomePage> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  Usuario get usuario => widget.usuario;

  void initState() {}

  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: HexColor("#6b4891"),
      appBar: AppBar(
        title: Text('Locafest'),
        actions: _buildActions(),
        backgroundColor: HexColor("#9C27B0"),
      ),
      body: _body(context),
      drawer: DrawerComponent(usuario),
    );
  }

  _body(BuildContext context) {
    double c_width = MediaQuery.of(context).size.width * 0.9;
    double c_height = MediaQuery.of(context).size.height * 0.9;

    return Form(
      key: _formKey,
      child: ListView(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              width: c_width * 0.79,
              height: c_height / 4,
              child: Card(
                child: Material(
                  color: Colors.amberAccent, // button color
                  child: InkWell(
                    splashColor: Colors.green, // splash color
                    onTap: () {
                      _novaReserva();
                    }, // button pressed
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        Icon(
                          Icons.car_rental,
                          size: c_width * 0.2,
                        ), // icon
                        Text(
                          "Nova Reserva",
                          style: TextStyle(
                            fontSize:
                                c_width * 0.1, // insert your font size here
                          ),
                        ), // text
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Container(
              width: c_width * 0.79,
              height: c_height / 4,
              child: Card(
                child: Material(
                  color: Colors.amberAccent, // button color
                  child: InkWell(
                    splashColor: Colors.green, // splash color
                    onTap: () {
                      _minhasReservas();
                    }, // button pressed
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        Icon(
                          Icons.receipt_long,
                          size: c_width * 0.2,
                        ), // icon
                        Text(
                          "Minhas Reservas",
                          style: TextStyle(
                            fontSize:
                                c_width * 0.1, // insert your font size here
                          ),
                        ), // text
                      ],
                    ),
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }

  _buildActions() {}

  _minhasReservas() {
    push(context, MinhasReservasPage(usuario));
  }

  _novaReserva() {
    push(context, NovaReservaPage(usuario));
  }
}
