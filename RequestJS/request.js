// Define skip and take values
const skip = 0; // Example: start from the first item
const take = 10; // Example: retrieve 10 items

// Construct the URL with query parameters
const url = `http://localhost:5001/api/v1/lawyer/getpage?skip=${skip}&take=${take}`;

var api_return = fetch(url)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json(); // Parse JSON response
    })
    .then(data => {
        // Process the data or store it as needed
        return data; // Return the parsed JSON data
    })
    .catch(error => {
        console.error('Fetch error:', error);
        throw error; // Re-throw the error to handle it further
    });

// Now api_return is a Promise that resolves to the parsed JSON data or rejects with an error


var id, nome, cpf;
// Example usage: You can chain another .then() to access the data when it resolves
api_return.then(data => {
    // console.log('API Response:', data[0]["id"]); // Log the first ID from the response
    id = data[0]["id"];
    nome = data[0]["name"];
    cpf = data[0]["cpf"];
    console.log('API Response:', data); // Log the parsed JSON data
}).catch(error => {
    console.error('Error:', error); // Handle any errors
});

// Note: Logging api_return directly will log the Promise object, not the data itself
console.log(api_return);
