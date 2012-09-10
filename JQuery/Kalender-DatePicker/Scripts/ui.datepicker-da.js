/* Danish initialisation for the jQuery UI date picker plugin. */
/* Written by Apone (angelopone@hotmail.com). */
jQuery(function($){
	$.datepicker.regional['da'] = {
		closeText: 'Luk',
		prevText: '&#x3c;Forr',
		nextText: 'N&aelig;st&#x3e;',
		currentText: 'Idag',
		monthNames: ['Januar','Februar','Marts','April','Maj','Juni','July','August','September','Oktober','November','December'],
		monthNamesShort: ['Jan','Feb','Mar','Apr','Maj','Jun','Jul','Aug','Sep','Okt','Nov','Dec'],
		dayNames: ['S&oslash;ndag','Mandag','Tirsdag','Onsdag','Tirsdag','Fredag','L&oslash;rdag'],
		dayNamesShort: ['S&oslash;n','Man','Tir','Ons','Tir','Fre','L&oslash;r'],
		dayNamesMin: ['S&oslash;','Ma','Ti','On','Ti','Fr','L&oslash;'],
		dateFormat: 'dd/mm/yy', firstDay: 1,
		isRTL: false};
	$.datepicker.setDefaults($.datepicker.regional['da']);
});
