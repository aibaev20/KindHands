class FormManager {

    // Static properties to reference DOM elements
    static volunteerForm = document.getElementById('volunteer-form');
    static organisationForm = document.getElementById('organisation-form');
    static volunteerButton = document.querySelector('.registration-option:nth-child(1)');
    static organisationButton = document.querySelector('.registration-option:nth-child(2)');

    static selectOption(option) {

        if (option === 'volunteer') {
            this.volunteerForm.classList.remove('hidden');
            this.organisationForm.classList.add('hidden');
            this.volunteerButton.classList.add('selected');
            this.organisationButton.classList.remove('selected');
        }
        else if (option === 'organisation') {
            this.organisationForm.classList.remove('hidden');
            this.volunteerForm.classList.add('hidden');
            this.volunteerButton.classList.remove('selected');
            this.organisationButton.classList.add('selected');
        }
    }

    static clearFormInputs() {

        this.organisationForm.reset();
        this.volunteerForm.reset();
    }
}