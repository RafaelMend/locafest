import 'dart:async';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:locafest/app/reserva/reserva_bloc.dart';
import 'package:locafest/app/shared/components/drawer_component.dart';
import 'package:locafest/app/shared/components/listview_component.dart';
import 'package:locafest/app/shared/entities/agendamento.dart';
import 'package:locafest/app/shared/entities/usuario.dart';
import 'package:locafest/app/shared/events/event_bus.dart';
import 'package:locafest/app/shared/events/events.dart';
import 'package:locafest/app/shared/utils/hex_color.dart';

class MinhasReservasPage extends StatefulWidget {
  @override
  _MinhasReservasPageState createState() => _MinhasReservasPageState();

  final Usuario usuario;

  MinhasReservasPage(this.usuario);
}

class _MinhasReservasPageState extends State<MinhasReservasPage> {

  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  Usuario get usuario => widget.usuario;
  ScrollController scrollController = ScrollController();
  final _bloc = ReservaBloc();
  List<Agendamento> agendamentos = List<Agendamento>();
  StreamSubscription subscription;

  @override
  initState() {
    super.initState();
    _bloc.fetch(false, usuario.id);

    // Event Bus
    subscription = eventBus.stream.listen((event) {
      print(">> event $event ");
      _onEvent(event);
    });
  }

  void _onEvent(event) {
    //obterIdsEscolasCarregados();
    if (event is ReservaEvent) {
      Agendamento e = event.agendamento;
      _bloc.fetch(false, usuario.id
      );
    }
  }

  @override
  Widget build(BuildContext cntext) {
    return Scaffold(
      backgroundColor: HexColor("#6b4891"),
      appBar: AppBar(
        title: Text('Locafest'),
        backgroundColor: HexColor("#9C27B0"),
      ),
      body: _body(context),
      drawer: DrawerComponent(usuario),
    );
  }

  _body(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(2),
      child: StreamBuilder(
        stream: _bloc.stream,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            final ReservaData reservasData = snapshot.data;

            agendamentos.addAll(reservasData.agendamentos);

            return ListViewComponent(agendamentos.toSet().toList(),
                scrollController: scrollController,
                scrollToTheEnd: reservasData.scrollToTheEnd);
          }
        },
      ),
    );
  }
}