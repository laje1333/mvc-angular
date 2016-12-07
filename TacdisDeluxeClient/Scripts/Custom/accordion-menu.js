$(function () {
    var simpleAccordionMenu = $('.accordion-menu');

    if (simpleAccordionMenu.length) {
        simpleAccordionMenu.find('a.accordion-menu-main-item-text').on('click', function () {
            simpleAccordionMenu.find('ul.accordion-sub-menu').hide('fast');
            $(this).closest('li').children('ul').show('fast');
        });
    }
});
