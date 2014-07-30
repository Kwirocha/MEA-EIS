function radioUnCheck() {
    var allRadios = $('input[type=radio]')
    var radioChecked;

    var setCurrent = function(e) {
        var obj = e.target;

        radioChecked = $(obj).attr('checked');
    }

    var setCheck = function(e) {

        if (e.type == 'keypress' && e.charCode != 32) {
            return false;
        }

        var obj = e.target;

        if (radioChecked) {
            $(obj).attr('checked', false);
        } else {
            $(obj).attr('checked', true);
        }
    }

    $.each(allRadios, function(i, val) {
        var label = $('label[for=' + $(this).attr("id") + ']');

        $(this).bind('mousedown keydown', function(e) {
            setCurrent(e);
        });

        label.bind('mousedown keydown', function(e) {
            e.target = $('#' + $(this).attr("for"));
            setCurrent(e);
        });

        $(this).bind('click', function(e) {
            setCheck(e);
        });

    });
}