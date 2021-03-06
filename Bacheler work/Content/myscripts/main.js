﻿

    var mymap = L.map('mapid').setView([51.505, -0.09], 13);
    var marker;
    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
        maxZoom: 18,
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, ' +
        '<a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
        'Imagery © <a href="http://mapbox.com">Mapbox</a>',
        id: 'mapbox.streets'
    }).addTo(mymap);

    function onMapClick(e) {

        if (marker != null)
        {
        mymap.removeLayer(marker);
    }
        marker = L.marker(e.latlng, {draggable: true }).addTo(mymap);
        marker.bindPopup("<b>Give me description</b>").openPopup();

        $("#inputForLocationFake").val(e.latlng.lng.toString().substr(0, 8) + " x " + e.latlng.lat.toString().substr(0, 8));
        $("#inputForLocation").val(e.latlng.lng.toString()+ "x" + e.latlng.lat.toString());

    }

    $(document).ready(function () {

        $("a[data-toggle='tab']").on('shown.bs.tab', function (e) {
            var target = $(e.target).attr("href") // activated tab
            //http://localhost:49190/Track/GetSensors
            if (target == "#menu1") {
                var jqxhr = $.getJSON("http://localhost:49190/api/GetSensors", function (data) {
                    for (var i = 0; i < data.length; i++) {
                        /*  $("<tr class='sensor'><td>" + data[i].Id + "</td><td>" +
                              data[i].phoneNumber + "</td><td>" + 
                              data[i].location+ "</td><td>" + 
                              data[i].description + "</td><td>" +
                              "<a href='/Sensors/Edit/" + data[i].Id + "'>Edit</a>"
  
                              +"</td><tr>" 
                          ).appendTo($(target).children());*/
  
                          var long = data[i].location.split("x")[0];
                          var lat = data[i].location.split("x")[1];
                        
                          var mark = L.marker([lat, long]);
                          mymap.setView([lat, long]);
                          mark.addTo(mymap);
                          mark.bindPopup(data[i].description).openPopup();
  
  
  
                      }
                  });
                      
              }
          });
  
  
      });
                        mymap.on('click', onMapClick);

                        $(".sensor").on("click", function (e) {

                            var loc = $(e.delegateTarget).find(".location").text();

                            var long = loc.split('x')[0];
                            var lat = loc.split('x')[1];
                            mymap.setView([lat, long]);

                        });


