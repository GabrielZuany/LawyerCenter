// Define skip and take values
const skip = 0; // Example: start from the first item
const take = 10; // Example: retrieve 10 items

// Construct the URL with query parameters
const url = `http://localhost:5001/api/v1/lawyer/getpage?skip=${skip}&take=${take}`;

// Make the fetch request
fetch(url)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json(); // Parse JSON response
    })
    .then(data => {
        console.log('Response:', data); // Log the JSON response
    })
    .catch(error => {
        console.error('Fetch error:', error);
    });
