const fs = require('fs');
module.exports = {
  devServer: {
    host: 'localhost',
    https: {
      key: fs.readFileSync('./artifacts/tls/localhost.key'),
      cert: fs.readFileSync('./artifacts/tls/localhost.crt'),
    },
    port: 5002,
    proxy: {
      '/login': {
        target: 'https://localhost:5001',
        xfwd: true
      },
      '/api': {
        target: 'https://localhost:5001',
        xfwd: true
       },
      '/security/external': {
        target: 'https://localhost:5001',
        xfwd: true
      },
      '/signin-twitch': {
        target: 'https://localhost:5001',
        xfwd: true
      }
    }
  }
}
