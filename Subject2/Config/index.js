const config = {
}

const prodConifg = {
    ...config,
    port: 8080
}

const devConfig = {
    ...config,
    port: 3020
}

if (process.env.NODE_ENV === 'production') {
    module.exports = prodConifg
} else {
    module.exports = devConfig
}