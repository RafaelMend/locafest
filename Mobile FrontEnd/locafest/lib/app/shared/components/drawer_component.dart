import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/home/home_page.dart';
import 'package:locafest/app/reserva/minhas_reservas_page.dart';
import 'package:locafest/app/reserva/nova_reserva_page.dart';
import 'package:locafest/app/shared/entities/usuario.dart';
import 'package:locafest/app/shared/utils/hex_color.dart';
import 'package:locafest/app/shared/utils/nav.dart';

class DrawerComponent extends StatelessWidget {
  final Usuario usuario;
  DrawerComponent(this.usuario);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(children: <Widget>[
        UserAccountsDrawerHeader(
          accountName: Text(usuario.cliente.nome),
          accountEmail: Text(usuario.cliente.cpf),
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
          Icons.car_rental,
          color: Colors.black,
        ),
      ),
      ListTile(
        onTap: () {
          _minhasReserva(context);
        },
        title: Text("Minhas Reserva"),
        leading: Icon(
          Icons.receipt_long,
          color: Colors.black,
        ),
      ),
    ]);
  }

  _novaReserva(BuildContext context) {
    push(context, NovaReservaPage(usuario));
  }

  _minhasReserva(BuildContext context) {
    push(context, MinhasReservasPage(usuario));
  }

  _clickHome(BuildContext context) {
    push(context, HomePage(usuario));
  }
}
