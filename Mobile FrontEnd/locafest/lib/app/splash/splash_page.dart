import 'package:flutter/material.dart';
import 'package:locafest/app/login/login_page.dart';
import 'package:locafest/app/shared/utils/hex_color.dart';

class Splash extends StatefulWidget {
  @override
  _SplashState createState() => _SplashState();
}

class _SplashState extends State<Splash> {

  Color gradientStart = HexColor("#6b4891"); //Change start gradient color here
  Color gradientCenter = HexColor("#e1bee7");
  Color gradientEnd = HexColor("#6b4891");

  @override
  void initState() {
    super.initState();
    Future.delayed(Duration(seconds: 2)).then((_){
      Navigator.pushReplacement(context, MaterialPageRoute(builder: (context)=>LoginPage()));
    });
  }

  @override
  Widget build(BuildContext context) {

    return Container(
        decoration: new BoxDecoration(
          gradient: new RadialGradient(
            center: const Alignment(0, 0), // near the top right
            radius: 0.7,
            colors: [
              gradientCenter,
              gradientStart,
            ],
            focal: Alignment(0, 0),
          ),
        ),
        child: Center(
          child: Container(
            width: 150,
            height: 150,
            child: Image.asset("assets/images/ic_carro.png"),
          ),
        )
    );
  }
}