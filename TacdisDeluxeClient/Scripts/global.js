
//  Sets accordion menu sub items to have a specific css class when clicked...
$(function () {
    var accordionMenuItemLink = $('.accordion-menu .accordion-sub-menu-item-text');

    if (accordionMenuItemLink.length) {
        accordionMenuItemLink.on('click', function () {
            accordionMenuItemLink.removeClass('marked');
            $(this).addClass('marked');
        });
    }
});


//  .alert-success, .alert-info, .alert-warning or .alert-danger
window.feedbackPopup = function (msg, options) {
    var level = (options === undefined || options.level === undefined) ? 'success' : options.level.toLowerCase();
    var timeout = (options === undefined || options.timeout === undefined) ? 2000 : options.timeout;
    var glyph = 'ok';


    switch (level.toLowerCase()) {
        case 'info':
            level = 'Info'
            glyph = 'info-sign';
            break;
        case 'warning':
        case 'danger':
            level = 'Danger'
            glyph = 'fire';
            break;
        default:
            level = 'Success';
            glyph = 'ok';
            break;
    }


    var msgBox = $('#__ajaxFeedbackMessage');

    msgBox.removeClass('alert-info').removeClass('alert-success').removeClass('alert-danger');
    msgBox.find('.message-level').removeClass('glyphicon-info-sign').removeClass('glyphicon-fire').removeClass('glyphicon-ok');

    msgBox.addClass('alert-' + level.toLowerCase());
    msgBox.find('.message-level').addClass('glyphicon-' + glyph);
    msgBox.find('.message-text').html(msg);
    msgBox.show('fast');
    setTimeout(function () { $('#__ajaxFeedbackMessage').fadeOut(500); }, timeout);
}

window.hotlinkToMenu = function () {
    var hash = window.location.hash;

    if (hash === "") {
        return;
    }

    hash = hash.replace('#', '');
    hash = hash.replace('/', '');

    $('.accordion-menu a[href!="#' + hash + '"]').removeClass('marked');
    var a = $('.accordion-menu').find('a[href="#' + hash + '"]');
    a.addClass('marked');
    a.closest('ul').css({ 'display': 'block' });
};
