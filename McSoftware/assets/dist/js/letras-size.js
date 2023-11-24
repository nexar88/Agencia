


const getFontSize = () => parseFloat(getComputedStyle(document.getElementById('panelRequisitos')).getPropertyValue('--font-size'))

const fontUp = element => {
    element.addEventListener('click', () => {
        let fontSize = getFontSize()
        document.getElementById('panelRequisitos')
            .style.setProperty('--font-size', `${fontSize * 1.1}`)
    })
}

const fontDown = element => {
    element.addEventListener('click', () => {
        let fontSize = getFontSize()
        document.getElementById('panelRequisitos')
            .style.setProperty('--font-size', `${fontSize * 0.9}`)
    })
}

fontUp(document.getElementById('font-up'))
fontDown(document.getElementById('font-down'))


addEventListener('keyup', e => {
    if (e.key === 'ArrowUp') document.getElementById('font-up').click()
    if (e.key === 'ArrowDown') document.getElementById('font-down').click()
})

