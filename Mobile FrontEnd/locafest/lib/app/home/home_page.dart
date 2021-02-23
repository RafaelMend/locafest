import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/utils/hex_color.dart';
import 'package:carousel_slider/carousel_slider.dart';

import 'drawer_component.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

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
      drawer: DrawerComponent(),
    );
  }

  _body(BuildContext context) {
    return Form(
      key: _formKey,
      child: Center(
          child: SizedBox.fromSize(
            size: Size(150, 150), // button width and height
            child: ClipOval(
              child: Material(
                color: Colors.amberAccent, // button color
                child: InkWell(
                  splashColor: Colors.green, // splash color
                  onTap: () {}, // button pressed
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      Icon(Icons.car_rental, size: 50,), // icon
                      Text("Nova Reserva"), // text
                    ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }

  _buildActions() {}
}
