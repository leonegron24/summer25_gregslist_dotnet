export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:7045' : ''
export const useSockets = false
// TODO use your own auth stuff
export const domain = 'dev-cxvcv5un0avbw1ix.us.auth0.com'
export const clientId = 'Wj3fnWeTZsH9Z4p5mDs1eYbsAGpGaNAP'
export const audience = 'https://auth.speedwagonfoundation.com'