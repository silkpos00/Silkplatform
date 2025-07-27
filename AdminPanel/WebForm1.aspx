<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdminPanel.WebForm1" %>

<!DOCTYPE html>
<html lang="fa" dir="rtl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>مولتی سلکت با چک‌باکس</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.rtl.min.css">
    <!-- Bootstrap-Select CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/css/bootstrap-select.min.css">
    <style>
        .dropdown-menu {
            max-height: 300px;
            overflow-y: auto;
        }
    </style>
</head>
<body>
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <label for="multiSelect" class="form-label">گزینه‌های خود را انتخاب کنید:</label>
                <select id="multiSelect" class="selectpicker w-100" multiple data-actions-box="true" title="انتخاب کنید...">
                    <option value="1">گزینه ۱</option>
                    <option value="2">گزینه ۲</option>
                    <option value="3">گزینه ۳</option>
                    <option value="4">گزینه ۴</option>
                    <option value="5">گزینه ۵</option>
                </select>
            </div>
        </div>
    </div>

    <!-- jQuery, Bootstrap JS و Bootstrap-Select JS -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.14.0-beta3/dist/js/bootstrap-select.min.js"></script>
    
    <script>
        $(document).ready(function() {
            // مقداردهی اولیه
            $('.selectpicker').selectpicker();
            
            // دریافت مقادیر انتخاب شده
            $('#btnGetSelected').click(function() {
                var selected = $('#multiSelect').val();
                alert('مقادیر انتخاب شده: ' + selected.join(', '));
            });
        });
    </script>
</body>
</html>