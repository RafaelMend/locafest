import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:flutter_map/plugin_api.dart';
import 'package:latlong/latlong.dart';
import 'package:location/location.dart';

class MapComponent extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return FlutterMap(
      options: new MapOptions(
        center: new LatLng(-19.90363, -43.94483),
        zoom: 13.0,
      ),
      layers: [
        new TileLayerOptions(
          urlTemplate: "https://atlas.microsoft.com/map/tile/png?api-version=1&layer=basic&style=main&tileSize=256&view=Auto&zoom={z}&x={x}&y={y}&subscription-key={subscriptionKey}",
          additionalOptions: {
            'subscriptionKey': 'B_fwlNi2o5RLOs5oOk86juHX-FwvZdVkH2sh0oEnlhQ'
          },
        ),
        new MarkerLayerOptions(
          markers: [
            new Marker(
              width: 80.0,
              height: 80.0,
              point: new LatLng(-19.90363, -43.94483),
              builder: (ctx) =>
              new Container(
                child: new FlutterLogo(),
              ),
            ),
          ],
        ),
      ],
    );
  }
}
