
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