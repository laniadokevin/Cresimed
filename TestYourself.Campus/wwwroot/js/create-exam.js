
function preventAllInteraction() {


	$(function () {
		$(this).bind("contextmenu", function (e) {
			e.preventDefault();
		});
	});
	/** TO DISABLE CUT COPY OR PASTE **/
	$(document).ready(function () {
		$('body').bind('cut copy paste', function (e) {
			e.preventDefault();
		});
	});

	/** TO DISABLE SCREEN CAPTURE **/
	document.addEventListener('keyup', (e) => {
		if (e.key == 'PrintScreen') {
			navigator.clipboard.writeText('');
		}
	});

	/** TO DISABLE PRINTS WHIT CTRL+P **/
	document.addEventListener('keydown', (e) => {
		if (e.ctrlKey && e.key == 'p') {
			e.cancelBubble = true;
			e.preventDefault();
			e.stopImmediatePropagation();
		}
	});
}


$(document).ready(function () {
	//preventAllInteraction();
	$("#inputTimer").hide();
	$("#switchTimer").on("click", function () {
		if ($("#switchTimer").prop("checked"))
			$("#inputTimer").show();
		else
			$("#inputTimer").hide();

    });
});

function validateCreateExamForm() {

	var textError = "";
	var valid = true;

	// cantidad preguntas
	if ($("#QuestionAmount").val() <= 0) {
		valid = false;
		textError = textError + " - La cantidad de preguntas no puede ser cero <br>";
	}

	// timer
	if ($("#switchTimer").prop("checked") && $("#TimerInput").val() <= 0) {
			valid = false;
			textError = textError + " - La cantidad de tiempo no puede ser cero <br>";
	}

	// 
	$("#radioButtonALL").prop("checked"),
	$("#radioButtonNEW").prop("checked"),
		$("#radioButtonINCORRECT").prop("checked")	


	if (valid)
		$("#FormCreateExam").submit();
	else
		$("#ErrorMsg").html(textError);
		
	
	

	
}
