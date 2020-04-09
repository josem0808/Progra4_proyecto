
const openLogButton = document.querySelector('[data-modal-target]')
const closeLogButton = document.querySelector('[data-close-button]')


openLogButton.addEventListener('click', () => {
	const modal = document.querySelector(openLogButton.dataset.modalTarget)
	openLog(modal)
})



closeLogButton.addEventListener('click', () => {
	const modal = closeLogButton.closest('.modal')
	closeLog(modal)
})



function openLog(modal) {
	if (modal == null) return
	modal.classList.add('active')
	overlay.classList.add('active')

}

function closeLog(modal) {
	if (modal == null) return
	modal.classList.remove('active')
	overlay.classList.remove('active')

}


function succes() {
	Swal.fire({
		position: 'top-end',
		icon: 'success',
		title: 'Your work has been saved',
		showConfirmButton: false,
		timer: 1500
	})

}

