# Dự án doc_task_remake

## Nhánh trong repository

- **main**: Nhánh chính thức, chỉ chứa các chức năng hoàn thiện và không còn lỗi.
- **develop**: Nhánh tích hợp các tính năng đã được kiểm thử.
  > Lưu ý: Các thành viên **không được commit trực tiếp vào main**.

## Quy tắc commit và branch

- Mỗi thành viên **tạo branch riêng** khi làm feature.
- **Tên branch** nên đặt theo chức năng/feature đang phát triển, ví dụ: (VD: api/auth/login, api/task/assigned-tasks,...)
  Lưu ý là cần tạo một DTO để các API sử dụng phải trả về success, data, message, error

- Trước khi bắt đầu code:

```bash
git pull origin develop
```

- Sau khi hoàn thành code:

```bash
git push origin <branch-name>
```

- Tạo pull request (PR) riêng để merge vào develop

## Quy tắc API

- Dùng chữ thường
- Nếu nhiều từ, dùng kebab-case

```bash
api/auth/login
api/task/assigned-task
```

- Dùng DTO để trả về các dữ liệu sau:

```bash
  "success": true|false,
  "data": ...,
  "message": "Thông báo",
  "error": "Thông tin lỗi nếu có"
```
