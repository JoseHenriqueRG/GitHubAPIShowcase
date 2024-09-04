import './Container.css'

function Container({customClass, children}){

    return <div className={`container ${customClass}`}>{children}</div>
}

export default Container