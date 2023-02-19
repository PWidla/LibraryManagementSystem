//  Announcement create form validation
$('#announcement-form-create').submit(function (e) {
    e.preventDefault();
    var title = $.trim($('#Title').val());
    var content = $.trim($('#Content').val());

    if (title.length == 0) {
        alert('Please enter title.');
        return;
    }
    if (content.length < 20) {
        alert('Content should be at least 20 characters long.');
        return;
    }

    var formData = new FormData(this);
    $.ajax({
        url: '/Announcements/Create',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            window.location.href = '/Announcements/Index';
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});

//  Announcement edit form validation
$('#announcement-form-edit').submit(function (e) {
    e.preventDefault();
    var title = $.trim($('#Title').val());
    var content = $.trim($('#Content').val());

    if (title.length == 0) {
        alert('Please enter title.');
        return;
    }
    if (content.length < 20) {
        alert('Content should be at least 20 characters long.');
        return;
    }

    var formData = new FormData(this);
    $.ajax({
        url: '/Announcements/Edit',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            window.location.href = '/Announcements/Index';
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});

//  Genre create form validation
$('#genre-form-create').submit(function (e) {
    e.preventDefault();
    var name = $.trim($('#Name').val());

    if (name.length == 0) {
        alert('Please enter name of genre.');
        return;
    }

    var formData = new FormData(this);
    $.ajax({
        url: '/Genres/Create',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            window.location.href = '/Genres/Index';
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});

//  Genre edit form validation
$('#genre-form-edit').submit(function (e) {
    e.preventDefault();
    var name = $.trim($('#Name').val());

    if (name.length == 0) {
        alert('Please enter name of genre.');
        return;
    }

    var formData = new FormData(this);
    $.ajax({
        url: '/Genres/Edit',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            window.location.href = '/Genres/Index';
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
});