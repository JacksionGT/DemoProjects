const config = {
}

const prodConifg = {
    ...config,
    port: 8080,
    apiHost: 'http://localhost:4894/api'
}

const devConfig = {
    ...config,
    port: 3020,
    apiHost: 'http://localhost:4894/api'
}

const mergedConfig = process.env.NODE_ENV === 'production' ? prodConifg : devConfig;
export default mergedConfig;