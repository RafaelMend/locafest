import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/home/home_page.dart';
import 'package:locafest/app/reserva/nova_reserva_page.dart';
import 'package:locafest/app/utils/hex_color.dart';
import 'package:locafest/app/utils/nav.dart';

class DrawerComponent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(children: <Widget>[
        UserAccountsDrawerHeader(
          accountName: Text("Nome"),
          accountEmail: Text("Matricula"),
          currentAccountPicture: FlutterLogo(),
        decoration: new BoxDecoration(
          color: HexColor("#9C27B0")
        ),
        ),
        Container(
          height: 500,
          child: _botoesDrawer(context),
        ),
      ]),
    );
  }

  _botoesDrawer(BuildContext context) {
    return ListView(children: <Widget>[
      ListTile(
        onTap: () {
          _clickHome(context);
        },
        title: Text("Home"),
        leading: Icon(
          Icons.account_balance,
          color: Colors.black,
        ),
      ),
      ListTile(
        onTap: () {
          _novaReserva(context);
        },
        title: Text("Nova Reserva"),
        leading: Icon(
          Icons.star,
          color: Colors.black,
        ),
      ),
      ListTile(
        onTap: () {
          _minhasReserva(context);
        },
        title: Text("Minhas Reserva"),
        leading: Icon(
          Icons.star,
          color: Colors.black,
        ),
      ),
    ]);
  }

  _novaReserva(BuildContext context) {
    push(context, NovaReservaPage());
  }

  _minhasReserva(BuildContext context) {}

  _clickHome(BuildContext context) {
    push(context, HomePage());
  }
}
