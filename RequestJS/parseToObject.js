class Lawyer {
    constructor(id, name, cpf, professionalId, lawyerCategoryId, postalcode, country, state, city, registrationDate, lastUpdate, photo, email, password) {
        this.id = id;
        this.name = name;
        this.cpf = cpf;
        this.professionalId = professionalId;
        this.lawyerCategoryId = lawyerCategoryId;
        this.postalcode = postalcode;
        this.country = country;
        this.state = state;
        this.city = city;
        this.registrationDate = new Date(registrationDate); // Convert string to Date object
        this.lastUpdate = lastUpdate ? new Date(lastUpdate) : null; // Convert string to Date object or null
        this.photo = photo;
        this.email = email;
        this.password = password;
    }
}
// Define skip and take values
const skip = 0; // Example: start from the first item
const take = 10; // Example: retrieve 10 items

// Construct the URL with query parameters
const url = `http://localhost:5001/api/v1/lawyer/getpage?skip=${skip}&take=${take}`;

fetch(url)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json(); // Parse JSON response
    })
    .then(data => {
        // Assuming data is an array of lawyers returned from API
        const lawyers = data.map(lawyerData => {
            // Map each object from API response to a Lawyer object
            return new Lawyer(
                lawyerData.id,
                lawyerData.name,
                lawyerData.cpf,
                lawyerData.professionalId,
                lawyerData.lawyerCategoryId,
                lawyerData.postalcode,
                lawyerData.country,
                lawyerData.state,
                lawyerData.city,
                lawyerData.registrationDate,
                lawyerData.lastUpdate,
                lawyerData.photo,
                lawyerData.email,
                lawyerData.password
            );
        });

        console.log('Mapped lawyers:', lawyers);

        // Now 'lawyers' contains an array of mapped Lawyer objects
    })
    .catch(error => {
        console.error('Fetch error:', error);
    });
