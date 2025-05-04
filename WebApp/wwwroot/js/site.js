
//tagit hjälp av chat-gpt för att optimera koden 
// Initiera alla Quill-redigerare
document.querySelectorAll('[data-quill-editor]').forEach(editorEl => {
    // debugger;
    const quill = new Quill(`#${editorEl.id}`, {
        modules: {
            syntax: true,
            toolbar: '#project-toolbar'
        },
        theme: 'snow',
        placeholder: 'Type something...'
    });

    const textarea = editorEl.closest('.form-group').querySelector('textarea');
    quill.on('text-change', () => {
        textarea.value = quill.root.innerHTML;
    });
});

// Dropdown-funktionalitet
document.querySelectorAll('[data-type="dropdown"]').forEach(button => {
    button.addEventListener('click', () => {
        const targetId = button.getAttribute('data-target');
        document.querySelector(`#${targetId}`).classList.toggle('dropdown-show');
    });
});

// Modal-funktionalitet
document.querySelectorAll('[data-type="modal"]').forEach(trigger => {
    trigger.addEventListener('click', () => {
        const targetId = trigger.getAttribute('data-target');
        document.querySelector(`#${targetId}`).classList.add('modal-show');
    });
});

document.querySelectorAll('[data-type="close"]').forEach(closeBtn => {
    closeBtn.addEventListener('click', () => {
        const targetId = closeBtn.getAttribute('data-target');
        document.querySelector(`#${targetId}`).classList.remove('modal-show');
    });
});

// Gemensam logik för alla filuppladdningar
document.querySelectorAll('[data-upload-group]').forEach(group => {
    const trigger = group.querySelector('[data-upload-trigger]');
    const fileInput = group.querySelector('input[type="file"]');
    const preview = group.querySelector('[data-upload-preview]');
    const iconContainer = group.querySelector('[data-upload-icon-container]');
    const icon = group.querySelector('[data-upload-icon]');

    trigger.addEventListener('click', () => fileInput.click());

    fileInput.addEventListener('change', (e) => {
        const file = e.target.files[0];
        if (file && file.type.startsWith('image/')) {
            const reader = new FileReader();
            reader.onload = (e) => {
                preview.src = e.target.result;
                preview.classList.remove('hide');
                iconContainer.classList.add('selected');
                icon.classList.replace('fa-camera', 'fa-pen-to-square');
            };
            reader.readAsDataURL(file);
        }
    });
});
