var observe;
if (window.attachEvent) {
    observe = function (element, event, handler) {
        element.attachEvent('on' + event, handler);
    };
}
else {
    observe = function (element, event, handler) {
        element.addEventListener(event, handler, false);
    };
}


$(function () {
    _bt_initFields();
});

function _bt_initFields() {
    $(':input[required]').each(function () {
        var msg = $(this).attr('data-message');
        var plh = $(this).attr('placeholder');
        if (typeof msg === 'undefined' && typeof plh !== 'undefined') {
            msg = 'Masukkan ' + plh.toLowerCase() + ' anda';
        }
        this.oninvalid = function () {
            this.setCustomValidity(msg);
        };
        this.oninput = function () {
            this.setCustomValidity('');
            _bt_checkReqFields(this);
        };
    });
    $('.input.input-password>.input-btn').on('click', function (evt) {
        evt.stopPropagation();
        return false;
    }).on('mousedown touchdown', function (evt) {
        evt.stopPropagation();
        var isrc = $('img', this).attr('src').replace('eye.png','eye1.png');
        $('img', this).attr('src', isrc);
        $(this).next(':input')[0].type = "text";
    }).on('mouseup touchup mouseout', function (evt) {
        evt.stopPropagation();
        var isrc = $('img', this).attr('src').replace('eye1.png', 'eye.png');
        $('img', this).attr('src', isrc);
        $(this).next(':input')[0].type = "password";
    });
    $('textarea.autoresize').each(function () {
        var text = this;
        function resize() {
            text.style.height = 'auto';
            text.style.height = text.scrollHeight + 'px';
        }
        /* 0-timeout to get the already changed text */
        function delayedResize() {
            window.setTimeout(resize, 0);
        }
        observe(text, 'change', resize);
        observe(text, 'cut', delayedResize);
        observe(text, 'paste', delayedResize);
        observe(text, 'drop', delayedResize);
        observe(text, 'keydown', delayedResize);

        text.focus();
        text.select();
        resize();
    });
    $(':input[type="checkbox"]').each(function () {
        if ($(this).closest('label.customcb').length === 0) {
            $(this).wrap('<label class="customcb"></label>');
        }
        if (!$(this).next().is('span.customcb_marker')) {
            $(this).after('<span class="customcb_marker"></span>');
        }
    });
}

function _bt_checkReqFields(obj) {
    var allFilled = true;
    var scope = $(obj).closest('form');
    if (scope.length === 0) scope = $('body');
    $(':input[required]', scope).each(function () {
        if ($(this).val().replace(/\s/gi, '') === '') {
            allFilled = false;
            return;
        }
    });
    if (allFilled) {
        if (!scope.hasClass('form-ready')) scope.addClass('form-ready');
    } else scope.removeClass('form-ready');
}

function _bt_checkFormValidity() {
    $('form')[0].reportValidity();
}

function _bt_msgDismiss(obj) {
    $(obj).animate({ bottom: '100%', opacity: 0 }, 'linear', function () {
        $(this).remove();
    });
}

