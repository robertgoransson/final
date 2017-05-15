<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false&libraries=places"></script>  
<script type="text/javascript">  
        google.maps.event.addDomListener(window, 'load', function () {  
            var options = {  
                types: ['(cities)'],  
                componentRestrictions: { country: "in" }  
            };  
  
            var input = document.getElementById('Address');  
            var places = new google.maps.places.Autocomplete(input, options);  
  
  
        });  
</script>  