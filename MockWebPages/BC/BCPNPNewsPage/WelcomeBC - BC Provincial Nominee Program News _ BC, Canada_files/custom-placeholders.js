/**
 * Search Results
 *
 */
define([
  'jquery'
], function($) {

  $(document).ready(function() {

    var input = document.querySelectorAll('.custom-input-placeholder-wrap');

    var onAutoFillStart = function(e) {
      $(e.target).each(function() {
        $(this).addClass('not-empty');
      });
    }

    var onAutoFillCancel = function(e) {
      $(e.target).each(function() {
        if ($(this).val().length > 0) {
          $(this).addClass('not-empty');
        } else {
          $(this).removeClass('not-empty');
        }
      });
    }

    for (var i = 0; input.length > i; i++) {
      input[i].addEventListener('animationstart', function(e) {
        switch (e.animationName) {
          case 'onAutoFillStart':
            return onAutoFillStart(e);

          case 'onAutoFillCancel':
            return onAutoFillCancel(e);
        }
      })
    }

    $('.custom-input-placeholder-wrap input').each(function() {
      $(this).on('change keyup input', function(e) {
        if ($(this).val().length > 0) {
          $(this).addClass('not-empty');
        } else {
          $(this).removeClass('not-empty');
        }
      });
    });

  });

});
