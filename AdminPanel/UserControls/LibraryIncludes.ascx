<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LibraryIncludes.ascx.cs" Inherits="AdminPanel.UserControls.LibraryIncludes" %>
<link rel="icon" type="image/x-icon" href="../../assets/img/favicon/favicon.ico" />
<link rel="preconnect" href="https://fonts.googleapis.com" />
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
<link href="https://fonts.googleapis.com/css2?family=Public+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;1,300;1,400;1,500;1,600;1,700&display=swap" rel="stylesheet" />
<link rel="stylesheet" href="../../assets/vendor/fonts/iconify-icons.css" />
<link rel="stylesheet" href="../../assets/vendor/libs/pickr/pickr-themes.css" />
<link rel="stylesheet" href="../../assets/vendor/css/core.css" />
<link rel="stylesheet" href="../../assets/css/demo.css" />
<link rel="stylesheet" href="../../assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css" />
<link rel="stylesheet" href="../../assets/vendor/fonts/flag-icons.css" />
<link rel="stylesheet" href="../../assets/vendor/libs/apex-charts/apex-charts.css" />
<link rel="stylesheet" href="../../assets/vendor/libs/bs-stepper/bs-stepper.css" />
<link rel="stylesheet" href="../../assets/vendor/libs/bootstrap-select/bootstrap-select.css" />
<link rel="stylesheet" href="../../assets/vendor/libs/select2/select2.css" />

<link rel="stylesheet" href="../../assets/vendor/libs/flatpickr/flatpickr.css">
<link rel="stylesheet" href="../../assets/vendor/libs/bootstrap-daterangepicker/bootstrap-daterangepicker.css">
<link rel="stylesheet" href="../../assets/vendor/libs/jquery-timepicker/jquery-timepicker.css">
<link rel="stylesheet" href="../../assets/vendor/libs/pickr/pickr-themes.css">
 <link rel="stylesheet" href="../../assets/vendor/libs/@form-validation/form-validation.css" />

<script src="../../assets/vendor/libs/jquery/jquery.js"></script>
<script src="../../assets/vendor/libs/popper/popper.js"></script>
<script src="../../assets/vendor/js/bootstrap.js"></script>
<script src="../../assets/vendor/libs/moment/moment.js"></script>
<script src="../../assets/vendor/libs/@algolia/autocomplete-js.js"></script>
<script src="../../assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js"></script>
<script src="../../assets/vendor/libs/hammer/hammer.js"></script>
<script src="../../assets/vendor/libs/i18n/i18n.js"></script>
<script src="../../assets/vendor/js/menu.js"></script>
<script src="../../assets/vendor/js/helpers.js"></script>
<script src="../../assets/vendor/js/template-customizer.js"></script>
<script src="../../assets/js/config.js"></script>


<!-- LibraryIncludes.ascx -->

<link rel="stylesheet" href="../../assets/daatTable/jquery.dataTables.min.css" />
<link rel="stylesheet" href="../../assets/daatTable/buttons.dataTables.min.css" />
<%--<script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>--%>
<script src="../../assets/daatTable/jquery.dataTables.min.js"></script>
<script src="../../assets/daatTable/dataTables.buttons.min.js"></script>
<script src="../../assets/daatTable/jszip.min.js"></script>
<script src="../../assets/daatTable/pdfmake.min.js"></script>
<script src="../../assets/daatTable/vfs_fonts.js"></script>
<script src="../../assets/daatTable/buttons.html5.min.js"></script>
<script src="../../assets/daatTable/buttons.print.min.js"></script>
<script src="../../assets/daatTable/dataTables.colReorder.min.js"></script>
<script src="../../assets/daatTable/buttons.colVis.min.js"></script>


<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
<link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
<style>
    table.dataTable,
    .dataTables_wrapper,
    .dataTables_wrapper .dataTables_info,
    .dataTables_wrapper .dataTables_paginate,
    .dropdown-menu,
    .filter-toggle,
    .dropdown-filter label,
    .dropdown-filter div {
        font-family: 'Roboto', 'Segoe UI', sans-serif !important;
        font-size: 13px !important;
    }

        table.dataTable thead th {
            font-weight: 500;
            position: relative;
        }

    #myTable tbody tr.selected {
        background-color: #cce5ff !important;
    }

    .dropdown-filter {
        position: relative;
    }

    .dropdown-menu {
        display: none;
        position: absolute;
        background: white;
        border: 1px solid #ccc;
        padding: 10px;
        max-height: 200px;
        overflow-y: auto;
        z-index: 10000;
        cursor: auto !important;
        min-width: 150px;
    }

        .dropdown-menu label {
            cursor: pointer;
            user-select: none;
            display: block;
            margin-bottom: 4px;
        }

    .column-title {
        font-weight: 600;
        margin-bottom: 4px;
    }

    @media print {
        /* مخفی کردن تمام عناصر ناخواسته با روش قطعی */
        tr.filter-row,
        .filter-toggle,
        .dropdown-menu,
        .dataTables_filter,
        .dataTables_length,
        .dt-buttons,
        .dataTables_info,
        .dataTables_paginate {
            display: none !important;
            height: 0 !important;
            width: 0 !important;
            padding: 0 !important;
            margin: 0 !important;
            border: none !important;
            visibility: hidden !important;
            position: absolute !important;
            overflow: hidden !important;
            clip: rect(0, 0, 0, 0) !important;
        }

        /* نمایش هدر اصلی با روش قطعی */
        thead tr.main-header {
            display: table-row !important;
            visibility: visible !important;
            height: auto !important;
            position: relative !important;
        }

        /* استایل‌های جدول برای پرینت */
        table {
            width: 100% !important;
            border-collapse: collapse !important;
            page-break-inside: auto !important;
        }

        thead {
            display: table-header-group !important;
        }

            thead th {
                background-color: #f1f1f1 !important;
                color: #000 !important;
                font-weight: bold !important;
                border: 1px solid #ddd !important;
                padding: 8px !important;
                page-break-inside: avoid !important;
            }

        tbody td {
            border: 1px solid #ddd !important;
            padding: 8px !important;
            page-break-inside: avoid !important;
        }

        /* حذف فضای اضافی */
        body, .card, .card-body {
            padding: 0 !important;
            margin: 0 !important;
            width: 100% !important;
        }
    }
    /* صفحه‌بندی را به صورت افقی قرار بده */
    /* اطمینان از اینکه تمام دکمه‌ها (از جمله prev و next) گرد هستن */
    .dataTables_wrapper .dataTables_paginate .paginate_button,
    .dataTables_wrapper .dataTables_paginate .paginate_button.previous,
    .dataTables_wrapper .dataTables_paginate .paginate_button.next {
        white-space: nowrap;
        min-width: 38px;
        height: 38px;
        padding: 0 10px;
        margin: 0 4px;
        border-radius: 50px !important;
        display: inline-flex !important;
        align-items: center;
        justify-content: center;
        border: 1px solid #0d6efd;
        background-color: #fff;
        color: #0d6efd;
        font-weight: bold;
        font-size: 14px;
        cursor: pointer;
        transition: all 0.3s;
    }

        /* دکمه فعال */
        .dataTables_wrapper .dataTables_paginate .paginate_button.current {
            background-color: #0d6efd;
            color: #fff;
            box-shadow: 0 0 5px rgba(13, 110, 253, 0.5);
        }
        /* هاور */
        .dataTables_wrapper .dataTables_paginate .paginate_button:hover {
            background-color: #0d6efd;
            color: #fff;
        }
        /* دکمه‌های غیرفعال (صفحه اول یا آخر) همون ظاهر عادی رو داشته باشن، فقط رنگشون کم‌رنگ‌تر باشه */
        .dataTables_wrapper .dataTables_paginate .paginate_button.disabled {
            opacity: 0.5 !important;
            pointer-events: none;
            border: 1px solid #0d6efd !important;
            border-radius: 50px !important;
            background-color: #fff !important;
            color: #0d6efd !important;
            box-shadow: none !important;
        }

    .dataTables_filter {
        display: none !important;
    }
    /* مرکز‌چین کردن pagination */
    div.dataTables_wrapper div.dataTables_paginate {
         white-space: nowrap !important;
    overflow-x: auto;
    text-align: center !important;
    float: none !important;
    }
    div.dataTables_wrapper div.text-end {
    min-width: 200px;
}
</style>
