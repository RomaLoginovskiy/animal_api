// Simple function to get pictures
function getPictures() {
    // Get values from the form
    var animalType = document.getElementById('animalType').value;
    var pictureCount = document.getElementById('pictureCount').value;
    var pictureWidth = document.getElementById('pictureWidth').value;
    var pictureHeight = document.getElementById('pictureHeight').value;
    
    // Show loading message
    document.getElementById('loading').style.display = 'block';
    document.getElementById('error').style.display = 'none';
    document.getElementById('pictures').innerHTML = '';
    
    // Make requests one by one
    for (var i = 0; i < pictureCount; i++) {
        getOnePicture(animalType, i + 1, pictureWidth, pictureHeight);
    }
}

// Function to get one picture
function getOnePicture(animalType, number, width, height) {
    var url = 'http://localhost:5076/api/Animal/picture/?type=' + animalType + '&width=' + width + '&height=' + height;
    
    fetch(url)
        .then(function(response) {
            if (response.ok) {
                return response.blob();
            } else {
                throw new Error('Failed to get picture');
            }
        })
        .then(function(blob) {
            showPicture(blob, animalType, number, width, height);
        })
        .catch(function(error) {
            showError('Error getting picture: ' + error.message);
        });
}

// Function to show a picture
function showPicture(blob, animalType, number, width, height) {
    var imageUrl = URL.createObjectURL(blob);
    
    var img = document.createElement('img');
    img.src = imageUrl;
    img.alt = animalType + ' picture ' + number;
    img.style.width = width + 'px';
    img.style.height = height + 'px';
    img.style.margin = '10px';
    
    document.getElementById('pictures').appendChild(img);
    document.getElementById('loading').style.display = 'none';
}

// Function to show error
function showError(message) {
    document.getElementById('error').textContent = message;
    document.getElementById('error').style.display = 'block';
    document.getElementById('loading').style.display = 'none';
}
