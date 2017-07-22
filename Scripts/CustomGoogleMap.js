
function initMap() {

    var card;
    var input = document.getElementById('locationSearch');

    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 45.5, lng: -75.8 },
        zoom: 10
    });

    var autocomplete = new google.maps.places.Autocomplete(input);

    // Bind the map's bounds (viewport) property to the autocomplete object,
    // so that the autocomplete requests use the current map bounds for the
    // bounds option in the request.
    autocomplete.bindTo('bounds', map);

    var infowindow = new google.maps.InfoWindow();
    var infowindowContent = document.getElementById('infowindow-content');
    infowindow.setContent(infowindowContent);
    var marker = new google.maps.Marker({
        map: map,
        anchorPoint: new google.maps.Point(0, -29)
    });

    autocomplete.addListener('place_changed', function () {
        infowindow.close();
        marker.setVisible(false);
        var place = autocomplete.getPlace();

        if (!place.geometry) {
            // User entered the name of a Place that was not suggested and
            // pressed the Enter key, or the Place Details request failed.
            window.alert("No details available for input: '" + place.name + "'");
            return;
        }

        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);  // Why 17? Because it looks good.
        }
        marker.setPosition(place.geometry.location);
        marker.setVisible(true);

        infowindowContent.children['place-name'].textContent = place.name;
        infowindowContent.children['place-address'].textContent = place.formatted_address;
        infowindow.open(map, marker);

        $("#LocationName").val(place.name);
        $("#Address").val(place.formatted_address);
        $("#Latitude").val(place.geometry.location.lat());
        $("#Longitude").val(place.geometry.location.lng());
        $("#MapUrl").val(place.url);
        $("#PlaceId").val(place.place_id);

    });
}
function initCity() {

    var card;
    var input = document.getElementById('citySearch');

    var options = {
        types: ['(cities)']
    };

    var autocomplete = new google.maps.places.Autocomplete(input, options);

    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();

        if (!place.geometry) {
            window.alert("No details available for input: '" + place.name + "'");
            return;
        }
        
        $("#City").val(place.formatted_address);
        $("#Latitude").val(place.geometry.location.lat());
        $("#Longitude").val(place.geometry.location.lng());

    });
}