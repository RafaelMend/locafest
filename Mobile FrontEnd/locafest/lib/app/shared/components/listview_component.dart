import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:locafest/app/shared/entities/agendamento.dart';
import 'package:locafest/app/shared/utils/hex_color.dart';

class ListViewComponent extends StatefulWidget {
  final List<Agendamento> agendamentos;
  final bool search;
  final ScrollController scrollController;
  final bool showProgress;
  final bool scrollToTheEnd;

  ListViewComponent(this.agendamentos,
      {this.search = false,
        this.scrollController,
        this.showProgress = false,
        this.scrollToTheEnd = false});

  @override
  _ListViewComponentState createState() => _ListViewComponentState();
}

class _ListViewComponentState extends State<ListViewComponent> {
  bool get showProgress => widget.showProgress;

  List<Agendamento> get agendamentos => widget.agendamentos;

  ScrollController get scrollController => widget.scrollController;

  @override
  Widget build(BuildContext context) {
    double c_width = MediaQuery.of(context).size.width * 0.8;
    Widget _buildTaileData(c) => Container(
      margin: EdgeInsets.only(bottom: 5),
      height: 380,
      child: Card(
        child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Container(
                constraints: new BoxConstraints.expand(
                  height: 200,
                  width: 400,
                ),
                decoration: new BoxDecoration(
                  image: new DecorationImage(
                    fit: BoxFit.fill,
                    image: AssetImage(
                      "assets/images/ic_carro_inicial.png",
                    ),
                  ),
                ),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: <Widget>[
                    IconButton(
                      icon: Icon(
                        Icons.star,
                        color: Colors.yellow,
                      )
                    ),
                  ],
                ),
              ),
              Container(
                height: 90,
                child: Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: Text(
                    "Em construção",
                    style: TextStyle(
                        fontSize: 16,
                        color: Colors.black,
                        fontWeight: FontWeight.bold),
                  ),
                ),
              ),
              Container(
                height: 30,
                child: Row(
                  children: <Widget>[
                    Padding(
                      padding: const EdgeInsets.fromLTRB(12, 0, 0, 0),
                      child: Icon(
                        Icons.location_on,
                        color: Colors.black,
                      ),
                    ),
                    Container(
                      width: c_width,
                      child: Text("Local",
                        style: TextStyle(fontSize: 12, color: Colors.black),
                      ),
                    ),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 8, 0, 8),
                child: Divider(
                  color: Colors.black,
                  height: 0,
                ),
              ),
            ]),
      ),
    );
    return ListView.builder(
        itemCount: agendamentos.length,
        itemBuilder: (ctx, idx) {
          var t = agendamentos.length;
          if (idx == agendamentos.length - 1) {
            return Center(child: CircularProgressIndicator());
          } else {
            final c = widget.agendamentos[idx];
            return _buildTaileData(c);
          }
        });
  }

  _onClick() {
  }

  _onClickDetalhes() {
  }
}
