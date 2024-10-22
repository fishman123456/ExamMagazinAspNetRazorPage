document.getElementById('login-form').addEventListener('submit', function(event) {
    event.preventDefault(); // Отменяем стандартное поведение формы

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const messageElement = document.getElementById('message');

    // Пример проверки логина и пароля (нужно заменить на реальную проверку)
    if (username === 'user' && password === 'password') {
        messageElement.style.color = 'green';
        messageElement.textContent = 'Успешный вход!';
        // Здесь можно выполнить дальнейшие действия, например, перенаправление на другую страницу
    } else {
        messageElement.style.color = 'red';
        messageElement.textContent = 'Неверный логин или пароль.';
    }
});