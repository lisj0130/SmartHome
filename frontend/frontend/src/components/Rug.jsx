import { useLoader } from '@react-three/fiber';
import { TextureLoader } from 'three';
import texture from '../assets/rug.jpg';

export default function Rug() {
    // Ladda in texturen (lägg din bild i public-mappen, t.ex. /textures/rug.jpg)
    const rugTexture = useLoader(TextureLoader, texture);

    return (
        <mesh rotation={[-Math.PI / 2, 0, 0]} position={[3, -2.98, -3.2]}>
            {/* Plane som matta */}
            <planeGeometry args={[11, 13]} /> {/* bredd, höjd i meter */}
            <meshStandardMaterial map={rugTexture} />
        </mesh>
    );
}
