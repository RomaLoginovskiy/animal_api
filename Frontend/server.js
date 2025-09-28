// Simple Node.js server to serve the frontend files
const express = require('express');
const path = require('path');

// Create the app
const app = express();
const port = 3000;

// Serve static files (HTML, CSS, JS)
app.use(express.static(__dirname));

// Main route - serve the index.html file
app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname, 'index.html'));
});

// Start the server
app.listen(port, '0.0.0.0', function() {
    console.log('Frontend server running at http://0.0.0.0:' + port);
    console.log('Open your browser and go to http://localhost:' + port);
});
